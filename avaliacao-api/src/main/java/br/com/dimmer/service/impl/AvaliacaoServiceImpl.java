package br.com.dimmer.service.impl;

import java.io.Serializable;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import br.com.dimmer.domain.Avaliacao;
import br.com.dimmer.repository.AvaliacaoRepository;
import br.com.dimmer.service.IAvaliacaoService;

@Service
public class AvaliacaoServiceImpl implements Serializable, IAvaliacaoService {
	
	private static final long serialVersionUID = 1L;
	
	@Autowired
	private AvaliacaoRepository avaliacaoRepository;

	@Override
	public Avaliacao buscarPor(long codigo) {
		return avaliacaoRepository.buscar(codigo);
	}

	@Override
	public List<Avaliacao> listar() {
		return avaliacaoRepository.listar();
	}

	@Override
	public Avaliacao inserir(Avaliacao avaliacao) {
		return avaliacaoRepository.salvar(avaliacao);
	}
	
}

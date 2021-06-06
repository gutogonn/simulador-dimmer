package br.com.dimmer.service;

import java.io.Serializable;
import java.util.List;

import br.com.dimmer.domain.Avaliacao;

public interface IAvaliacaoService extends Serializable {
	
	public Avaliacao buscarPor(long codigo);
	public List<Avaliacao> listar();
	public Avaliacao inserir(Avaliacao avaliacao);
	
}

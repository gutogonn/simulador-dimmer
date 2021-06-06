package br.com.dimmer.repository.rowmapper;

import java.sql.ResultSet;
import java.sql.SQLException;

import org.springframework.jdbc.core.RowMapper;

import br.com.dimmer.domain.Avaliacao;

public class AvaliacaoRowMapper implements RowMapper<Avaliacao>{
	@Override
	public Avaliacao mapRow(ResultSet rs, int rowNum) throws SQLException {
		Avaliacao avaliacao = new Avaliacao();
		avaliacao.setCodigo(rs.getLong("codigo"));
		avaliacao.setNome(rs.getString("nome"));
		avaliacao.setErros(rs.getInt("erros"));
		avaliacao.setTempo(rs.getFloat("tempo"));
		return avaliacao;
	}
}
